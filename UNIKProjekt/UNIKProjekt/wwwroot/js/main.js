function ToggleSlide(e, id) {
    e.preventDefault();

    var cont = document.getElementById(id);
    var arrow = document.getElementById(id + '-arrow');
    cont.classList.toggle('on');

    if(arrow != null)
        arrow.classList.toggle('Open');
}

function CloseAlert(e, id) {
    e.preventDefault();

    var el = document.getElementById(id);

    if(el != undefined) {
        el.classList.add('fadeOut');
        setTimeout(function() { 
            el.remove();
        }, 400);
    } else {
        console.log("Alert element couldn't be found.");
    }
}