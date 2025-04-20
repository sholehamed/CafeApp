
export function Add(id) {
    var item = document.getElementById(id)
    changeQuantity(item, 1)
}
export function Minus(id) {
    var item = document.getElementById(id)
    event.preventDefault();
    changeQuantity(item, -1)
}
function changeQuantity(element, amount) {
    let countSpan = element.querySelector('.count');
    if (!countSpan) {
        countSpan = document.createElement('span');
        countSpan.className = 'count';
        countSpan.textContent = '0'; // شروع از 0
        element.appendChild(countSpan);
    }

    let count = parseInt(countSpan.textContent);
    count += amount;

    // جلوگیری از منفی شدن تعداد و بالاتر از 100 رفتن
    if (count < 1) {
        count = 0;
    } else if (count > 100) {
        count = 100;
    }

    // تنظیم مقدار
    countSpan.textContent = count;

    // نمایش/پنهان کردن countSpan و انتخاب رنگ برای آیتم‌ها
    if (count > 0) {
        countSpan.style.display = 'inline'; // نمایش countSpan
        element.classList.add('selected');
    } else {
        countSpan.style.display = 'none'; // پنهان کردن countSpan
        element.classList.remove('selected');
    }
}

export function enableDongi() {
    debugger
    var dongi = false
    if (!dongi) {  // وقتی که دنگی فعال نیست (یعنی dongi برابر false است)
        $('.dongi').removeClass('hide');
        $('.fishbtn').addClass('blurred');
        $('#btndongi').addClass('enabel');
        $('#btndongi').html(' تایید دنگی');

        // غیرفعال کردن دکمه‌های منفی بعد از تایید دنگی


        dongi = true;  // دنگی را فعال کنید
    } else {  // وقتی که دنگی فعال است (یعنی dongi برابر true است)
        $('.dongi').addClass('hide');
        $('.fishbtn').removeClass('blurred');
        $('#btndongi').removeClass('enabel');
        $('#btndongi').html(' تسویه دنگی');

        // فعال کردن دوباره دکمه‌های منفی


        dongi = false;  // دنگی را غیرفعال کنید
    }
}