export function ShowDialog(msg) {
    const popupOverlay = document.getElementById('popupOverlay');
    const popupClose = document.getElementById('popupClose');

    document.getElementById('msg-modal-text').innerHTML = msg;
    popupOverlay.style.display = 'flex';
    popupClose.addEventListener('click', function () {
        popupOverlay.style.display = 'none';
    });

}

export function GoToCategory(catId) {
    debugger
    var cat = document.getElementById(catId)
    window.scrollTo(cat.top)
}