// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(()=>{
    
    $('.btn-show').click((e)=>{
        if($('#chbajaxcall').prop("checked")){
            e.preventDefault();
            $.get( "/ajaxcall/"+e.target.id, function( data ) {
                console.log(data);
                $('#img').attr("class", "emogi "+data.img);
                $('#status').html(data.status);
                $('#fullness').html(data.fullness);
                $('#happiness').html(data.happiness);
                $('#meals').html(data.meals);
                $('#energy').html(data.energy);
                
              });
        }

    })
});