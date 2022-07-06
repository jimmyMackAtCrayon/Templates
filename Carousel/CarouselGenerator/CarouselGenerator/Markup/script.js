var slidePosition = 1;

SlideShow(slidePosition);

// forward/Back controls
function plusSlides(n) {
  SlideShow((slidePosition += n));
}

//  images controls
function currentSlide(n) {
  SlideShow((slidePosition = n));
}

function SlideShow(n) {
  console.log("SlideShow", n);
  var i;
  var slides = document.getElementsByClassName("Containers");
  var circles = document.getElementsByClassName("dots");
  console.log("SlideShow", slides.length);
  if (n > slides.length) {
    slidePosition = 1;
  }
  if (n < 1) {
    console.log("First", n);
    slidePosition = slides.length;
  }
  for (i = 0; i < slides.length; i++) {
    console.log("loop1", slides[i]);
    slides[i].style.display = "none";
  }
  for (i = 0; i < circles.length; i++) {
    console.log("loop2", slides[i]);
    circles[i].className = circles[i].className.replace(" enable", "");
  }
  console.log("Slide", slidePosition);
  slides[slidePosition - 1].style.display = "block";
  circles[slidePosition - 1].className += " enable";
}
