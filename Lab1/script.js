window.onload = function() {
let imgElement = document.getElementById('srcImage');
let inputElement = document.getElementById('fileInput');
  

imgElement.onload = function() {
  let mat = cv.imread(imgElement);
  let dst = new cv.Mat();
  let dst2 = new cv.Mat();
  cv.cvtColor(mat, dst, cv.COLOR_RGBA2GRAY);
  cv.imshow('outputCanvas', dst);
  cv.threshold(dst,dst2, 80, 255, cv.THRESH_BINARY);
  cv.imshow('outputCanvas2', dst2);
  mat.delete();
}

inputElement.addEventListener("change", (e) => {
  imgElement.src = URL.createObjectURL(e.target.files[0]);
}, false);
}
