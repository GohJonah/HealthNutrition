function StartSlideShow(slideshowId) {
    const myslideshow = document.querySelector(slideshowId)

    const slideshow = new bootstrap.Carousel(myslideshow, {
        interval: 1000,
        touch: false
    })
}