
$(window).scroll(function () {
    ResizeToolbar();
});

function ResizeToolbar() {
    // Fixes a problem with min-height not stretching correctly
    if ($(this).width() >= 767) {
        var newSize = $('.main-content').height();
        $('#toolbar').height(newSize);
    } else {
        $('#toolbar').height('auto');
    }
    console.log('resized');
}