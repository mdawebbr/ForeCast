$(".tirarfoto").click((e) => {
    e.preventDefault();
    $(".capturarfoto").trigger("click");
})

$(".capturarfoto").on('change', function(e) {
    
    $(".ftsel").text(e.target.files[0].name);
    $(".ftsel").removeClass("d-none");
})