#!/usr/bin/env python
import numpy as np
import cv2 as cv

MHI_DURATION = 0.5
DEFAULT_THRESHOLD = 32
MAX_TIME_DELTA = 0.25
MIN_TIME_DELTA = 0.05

# (empty) trackbar callback
def nothing(dummy):
    pass

if __name__ == '__main__':
    import sys
    video_src = 'runway.mp4'

    cv.namedWindow('motempl')
    cv.createTrackbar('threshold', 'motempl', DEFAULT_THRESHOLD, 255, nothing)

    cam = cv.VideoCapture(video_src)
    if not cam.isOpened():
        print("could not open video_src " + str(video_src) + " !\n")
        sys.exit(1)
    ret, frame = cam.read()
    if ret == False:
        print("could not read from " + str(video_src) + " !\n")
        sys.exit(1)
    h, w = frame.shape[:2]
    prev_frame = frame.copy()
    motion_history = np.zeros((h, w), np.float32) 
    hsv = np.zeros((h, w, 3), np.uint8)
    hsv[:,:,1] = 255
    while True:
        ret, frame = cam.read()
        if ret == False:
            break
        frame_diff = cv.absdiff(frame, prev_frame)#вычисление разности между двумя массивами
        gray_diff = cv.cvtColor(frame_diff, cv.COLOR_BGR2GRAY)
        thrs = cv.getTrackbarPos('threshold', 'motempl')
        ret, motion_mask = cv.threshold(gray_diff, thrs, 1, cv.THRESH_BINARY)#перевод в бинарный вид
        timestamp = cv.getTickCount() / cv.getTickFrequency()
        cv.motempl.updateMotionHistory(
            motion_mask,#Силуэт маски с ненулевыми пикселями, где происходит движение.
            motion_history, #Изображение истории обновлений, которое обновляется функцией
            timestamp,#текущее время
            MHI_DURATION)#Максимальная продолжительность дорожки движения
        mg_mask, mg_orient = cv.motempl.calcMotionGradient(motion_history, MAX_TIME_DELTA, MIN_TIME_DELTA, apertureSize=5 )
        seg_mask, seg_bounds = cv.motempl.segmentMotion(motion_history, timestamp, MAX_TIME_DELTA)

        vis = np.uint8(np.clip((motion_history-(timestamp-MHI_DURATION)) / MHI_DURATION, 0, 1)*255)
        vis = cv.cvtColor(vis, cv.COLOR_GRAY2BGR)
        
        for i, rect in enumerate([(0, 0, w, h)] + list(seg_bounds)):
            x, y, rw, rh = rect
            area = rw*rh
            if area < 64**2:
                continue
            silh_roi   = motion_mask   [y:y+rh,x:x+rw]
            orient_roi = mg_orient     [y:y+rh,x:x+rw]
            mask_roi   = mg_mask       [y:y+rh,x:x+rw]
            mhi_roi    = motion_history[y:y+rh,x:x+rw]
            if cv.norm(silh_roi, cv.NORM_L1) < area*0.05:
                continue
            angle = cv.motempl.calcGlobalOrientation(orient_roi, mask_roi, mhi_roi, timestamp, MHI_DURATION)
            color = ((255, 0, 0), (0, 0, 255))[i == 0]
            
        cv.imshow('motempl', vis)

        prev_frame = frame.copy()
        if 0xFF & cv.waitKey(5) == 27:
            break
    # cleanup the camera and close any open windows
    cam.release()
    cv.destroyAllWindows()
