$(document).on('submit', '#addMovieForm', function (e) {
    e.preventDefault();
    $("#CancelAddMovieModal").click();
    var formData = new FormData(this);
    $.ajax({
        cache: false,
        url: $(this).attr('action'),
        type: $(this).attr('method'),
        data: formData,
        contentType: false,
        processData: false,
        success: function (response) {
            let grid = `
                    <img class="card-img-top" style="width:100%; height:100px; margin-top: 15px;" src="data:image/png;base64, ${response.image}">
                    <div class="card-body">
                    <h5 class="card-title name">${response.name}</h5>
                    <p class="card-text"></p>
                    <a href="#editMovieModal" onclick="EditMovieClick(this,'${response.id}')" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit"></i><i class="fas fa-edit"></i></a>
                    <a href="#deleteMovieModal" onclick="DeleteMovieClick('${response.id}')" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete"></i><i class="fas fa-trash-alt"></i></a>
                    </div>`;
            $("#added_record").append(grid);
        }
    }); 
});

$(document).on('submit', '#editMovieForm', function (e) {
    e.preventDefault();
    $("#CancelEditMovieModal").click();

    let movieId = $(this).find(".MovieId").val();
    let movieName = $(this).find(".name").val();
    let movieImage = $(this).find(".image").prop('files')[0];
    
    var formData = new FormData();
    formData.append("Id", movieId);
    formData.append("Name", movieName);
    formData.append("Image", movieImage);
    formData.append("postedFile", movieImage);

    $.ajax({
        cache: false,
        url: $(this).attr('action'),
        type: $(this).attr('method'),
        data: formData,
        contentType: false,
        processData: false,
        success: function (response) {
            alert($(`#${added_record}`))
            $(`#${movieId}`).empty();
            let grid =`
                    <img class="card-img-top" style="width:100%; height:100px; margin-top: 15px;" src="data:image/png;base64, ${response.image}">
                    <div class="card-body">
                        <h5 class="card-title name">${response.name}</h5>
                        <p class="card-text"></p>
                        <a href="#editMovieModal" onclick="EditMovieClick(this,'${response.id}')" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit"></i><i class="fas fa-edit"></i></a>
                        <a href="#deleteMovieModal" onclick="DeleteMovieClick('${response.id}')" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete"></i><i class="fas fa-trash-alt"></i></a>
                    </div>`;
            $(`#${movieId}`).append(grid);
        }
    });
});

$(document).on('submit', '#deleteMovieForm', function (e) {
    e.preventDefault();
    $("#CanceldeleteMovieModal").click();
    let movieId = $(this).find(".MovieId").val();
    var formData = new FormData();
    formData.append("id", movieId);
    $.ajax({
        cache: false,
        url: $(this).attr('action'),
        type: $(this).attr('method'),
        data: formData,
        contentType: false,
        processData: false,
        success: function (response) {
            $(`#${movieId}`).remove();
            $(`#${movieId}`).empty();
            $("#row").hide().fadeIn('fast');
        }
    });
});


function DeleteMovieClick(movieId) {
    $("#deleteMovieModal .MovieId").val(movieId);
}

function EditMovieClick(elem, movieId) {
    $("#editMovieModal .MovieId").val(movieId);
    var name = $(elem.parentElement.parentElement).find(".name").text();
    $("#editMovieModal .name").val(name);
}