const mediaSource = new MediaSource();

function onStart() {
  /**
   * Определяем наличие медийных данных пользователя
   * Переопределяем метод получения данных для разных браузеров
   */
  navigator.getUserMedia = ( navigator.getUserMedia ||
                             navigator.webkitGetUserMedia ||
                             navigator.mozGetUserMedia ||
                             navigator.msGetUserMedia);
  //
  let video;
  var canvas;
  var take_button;
  var save_button;
  var message;
  //
    /**
     * Определяем ссылки на элементы 
     * управления используемые в примере
     */
    video =  document.getElementById("video");
    canvas = document.getElementById('canvas');
    take_button = document.getElementById('take_button');
    save_button = document.getElementById('save_button');
    message = document.getElementById('message');
    /**
     * Если нет возможности получить медийные данные, 
     * показываем соответсвующее сообщение и прекратим работу
     */
    if(!navigator.getUserMedia) 
    {
      message.innerHTML = 'Your browser does not support using the camera!';
      take_button.disabled = true;
      return;
    }
    /**
     * Получаем данные от браузера
     * В первом параметре указываем требования для данных
     * В нашем случае, это видео с веб-камеры
     */
    navigator.getUserMedia({ video : true }, 
    /**
     * Обрабатываем событие успешного получения данных
     * Задаем полученый поток видео элементу
     */
    function (stream)
    {
      if ('srcObject' in video) {
        video.srcObject = stream;
      } else {
        video.src = URL.createObjectURL(mediaSource);
      }
    }, 
   
    function ()
    {
      message.innerHTML = 'No access to the camera';
      take_button.disabled = true;
    });  
}

function onSobel(){
  let video =  document.getElementById("video");
  let height = 300;
  let width = 300;
  let canvasFrame = document.getElementById("canvas"); 
  let context = canvasFrame.getContext("2d");
  let src = new cv.Mat(height, width, cv.CV_8UC4);
  let dst = new cv.Mat(height, width, cv.CV_8UC4);
  const FPS = 30;
  function processVideo() {
      let begin = Date.now(context.getImageData(0, 0, width, height).data);
      context.drawImage(video, 0, 0, width, height);
      let img = context.getImageData(0, 0, width, height).data;
      src.data.set(img);
      cv.Sobel(src, dst, cv.CV_16S, 1, 0, 7);
      cv.imshow("canvas", dst);
      let delay = 1000/FPS - (Date.now() - begin);
      setTimeout(processVideo, delay);
  }
  setTimeout(processVideo, 0);
}

function onCanny(){
  let video =  document.getElementById("video");
  let height = 300;
  let width = 300;
  let canvasFrame = document.getElementById("canvas");
  let context = canvasFrame.getContext("2d");
  let src = new cv.Mat(height, width, cv.CV_8UC4);
  let dst = new cv.Mat(height, width, cv.CV_8UC4);
  const FPS = 30;
  function processVideo() {
      let begin = Date.now(context.getImageData(0, 0, width, height).data);
      context.drawImage(video, 0, 0, width, height);
      let img = context.getImageData(0, 0, width, height).data;
      src.data.set(img);
      cv.Canny(src, dst, 50, 100, 3, false);
      cv.imshow("canvas", dst); 
      let delay = 1000/FPS - (Date.now() - begin);
      setTimeout(processVideo, delay);
  }
  // schedule first one.
  setTimeout(processVideo, 0);
}

function onLaplac(){
  let video =  document.getElementById("video");
  let height = 300;
  let width = 300;
  let canvasFrame = document.getElementById("canvas"); 
  let context = canvasFrame.getContext("2d");
  let src = new cv.Mat(height, width, cv.CV_8UC4);
  let dst = new cv.Mat(height, width, cv.CV_8UC4);
  const FPS = 30;
  function processVideo() {
      let begin = Date.now(context.getImageData(0, 0, width, height).data);
      context.drawImage(video, 0, 0, width, height);
      let img = context.getImageData(0, 0, width, height).data;
      src.data.set(img);
      cv.Laplacian(src, dst, cv.CV_16S,7, 1, 21);
      cv.imshow("canvas", dst); 
      let delay = 1000/FPS - (Date.now() - begin);
      setTimeout(processVideo, delay);
  }
  setTimeout(processVideo, 0);
}