
$("#nav_Master").click(function () {

    var value = $("#nav_Master").css("max-height");

    if (value == "21px") {
        $("#nav_Master").css("max-height", "100rem");
        $("#nav_Master").find(".nav_dropdown-icon").css("transform", "rotate(180deg)");
    }
    else {
        $("#nav_Master").css("max-height", "21px");
        $("#nav_Master").find(".nav_dropdown-icon").css("transform", "rotate(0deg)");
    }

});


$("#nav_SingleTransfer").click(function(){

    var value = $("#nav_SingleTransfer").css("max-height");

    if(value == "21px"){
        $("#nav_SingleTransfer").css("max-height","100rem");
        $("#nav_SingleTransfer").find(".nav_dropdown-icon").css("transform","rotate(180deg)");
    }
    else{
        $("#nav_SingleTransfer").css("max-height","21px");
        $("#nav_SingleTransfer").find(".nav_dropdown-icon").css("transform","rotate(0deg)");
    }

});

$("#header-toggle,#header_title").click(function(){

    var value = $(".nav").css("left");
    if(value != "0px"){
        $(".nav").css("left","0");
    }else{
        $(".nav").css("left","-100%");
    }

});

//function onDeleteSingle(id) {
//    $("#DeleteModal").modal('show');
//}
