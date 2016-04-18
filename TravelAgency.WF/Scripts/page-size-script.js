function resize() {
    var newHeight = window.innerHeight - $("div.title-area").height() - 70;
    $("div.section-wrap").height(newHeight);
}

$(document).ready(resize);
window.onresize = function () {
    resize();
};