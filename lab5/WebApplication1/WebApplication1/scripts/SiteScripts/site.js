function confirmDelete(id) {
    let res = confirm("Are you sure?")
    console.log(res);
    console.log(id)
    if (res) {
        $.ajax({

            url: "/Employee/Delete/"+id,
            type: "POST",
            success: function (respone) {
                if (respone) {
                    let tr = $("#"+id)
                    tr.remove();
                }
            },
            error: function (xhr, status, err) {
                console.log(err);
            }
        })
    }
}
function onSuccess(employee) { //el microsoft jquery unabstrative ajax bt7wly el employee da mn json l obj 3ady
    document.getElementById("form0").reset();
    $("#exampleModal").modal("hide");
    //$("#tbody").append(employee); //estghnet 3anha b UpdateTargetId w insertionMode


}