// Write your JavaScript code.

$(document).ready(function() {
    $(".btnDelete").click(function () {
        var currentBtn = $(this);
        if (confirm("Do you want to delete this student")) {
            $.ajax({
                url: "/Student/Delete?id=" + currentBtn.attr("id"),
                method: "DELETE",
                success: function() {
                    $(".alert-success").text("Delete Success");
                    currentBtn.closest("li").remove();
                },
                error: function() {
                    $(".alert-danger").text("Delete Failed");
                }
            });
        }
    });
})