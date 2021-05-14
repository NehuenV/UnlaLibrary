function main() {
    let form = document.getElementsByTagName("form")[0];
    let formHeight = form.getBoundingClientRect().height;
    document.documentElement.style.setProperty('--formMiddleHeight', formHeight/1.2 + 'px');
    document.documentElement.style.setProperty('--formMiddleHeightNegative', '-' + formHeight/2 + 'px');

}

window.addEventListener('load', main)