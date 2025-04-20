export function enableDongi(d) {
    debugger
    if (!d) {  // وقتی که دنگی فعال نیست (یعنی dongi برابر false است)
        $('.dongi').removeClass('hide');
        $('.fishbtn').addClass('blurred');
        $('#btndongi').addClass('enabel');
        $('#btndongi').html(' تایید دنگی');

        // غیرفعال کردن دکمه‌های منفی بعد از تایید دنگی


        d = true;  // دنگی را فعال کنید
    } else {  // وقتی که دنگی فعال است (یعنی dongi برابر true است)
        $('.dongi').addClass('hide');
        $('.fishbtn').removeClass('blurred');
        $('#btndongi').removeClass('enabel');
        $('#btndongi').html(' تسویه دنگی');

        // فعال کردن دوباره دکمه‌های منفی


        d = false;  // دنگی را غیرفعال کنید
    }
}