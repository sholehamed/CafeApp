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
    
    var cat = document.getElementById(catId)
    var p=cat.offsetTop+70
    document.getElementsByClassName('menubody')[0].scrollTo({top:p,behavior:'smooth'})
    //cat.scrollIntoView({  ,behavior:'smooth',block:"center"})
}