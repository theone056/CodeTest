// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    let tableClass = $('#myTableClass').DataTable();
    let tableStudent = $('#myTableStudent').DataTable();

    //on Click on Class Table
    $('#myTableClass tbody').on("click", 'tr', function () {
        let data = tableClass.row(this).data();
        GetStudents(data[0]);
    });
    //Add button for Class Data
    $(".add-button").on("click", async function () {
        Swal.fire({
            title: 'Add Class',
            html: `<input type="text" id="className" class="swal2-input" placeholder="Class Name">
                    <input type="text" id="location" class="swal2-input" placeholder="Location">
                    <input type="text" id="teacherName" class="swal2-input" placeholder="Teacher Name">`,

            confirmButtonText: 'Add',
            focusConfirm: false,
            preConfirm: () => {
                const classname = Swal.getPopup().querySelector('#className').value
                const location = Swal.getPopup().querySelector('#location').value
                const teacherName = Swal.getPopup().querySelector("#teacherName").value;
                if (!classname || !location || !teacherName) {
                    Swal.showValidationMessage(`Please enter value`)
                }
                return { classname: classname, location: location, teacherName: teacherName }
            }
        }).then((result) => {
            let url = "Home/AddClass";
            $.post(url, result.value).done(function (data) {
                if (data === "1") {
                    Swal.fire(
                        'Success!',
                        'Data added successfuly!',
                        'success'
                    )
                    let url = "Home/GetClasses";
                    $.get(url, function (result, status) {
                        tableClass.clear().draw();
                        result.map((res) => {
                            tableClass.row.add([
                                res.className,
                                res.location,
                                res.teacherName,
                                "<button id='edit-class'>Edit</button>",
                                "<button id='delete-class'>Delete</button>",
                            ]).draw(false);
                        })
                    });

                }
                else if (data === "Duplicate Class") {
                    Swal.fire(
                        'Error!',
                        data,
                        'error'
                    )
                }
                else {
                    Swal.fire(
                        'Error!',
                        data,
                        'error'
                    )
                }
            });
        })
    })

    //Add button for Student
    $(".add-button-student").on("click", async function () {
        const className = $("#classValue").text();
        if (className !== "") {
            Swal.fire({
                title: 'Add Student',
                html: `<input type="text" id="firstName" class="swal2-input" placeholder="First Name">
                    <input type="text" id="lastName" class="swal2-input" placeholder="Last Name">
                    <input type="text" id="age" class="swal2-input" placeholder="Age">
                    <input type="text" id="gpa" class="swal2-input" placeholder="GPA">`,
                confirmButtonText: 'Add',
                focusConfirm: false,
                preConfirm: () => {
                    const firstName = Swal.getPopup().querySelector('#firstName').value
                    const lastName = Swal.getPopup().querySelector('#lastName').value
                    const age = Swal.getPopup().querySelector("#age").value;
                    const gpa = Swal.getPopup().querySelector("#gpa").value;
                    if (!firstName || !lastName || !age || !gpa) {
                        Swal.showValidationMessage(`Please enter a valid value`)
                    }
                    return { FirstName: firstName, LastName: lastName, Age: age, GPA: gpa, ClassName: className }
                }
            }).then((result) => {
                let url = "Home/AddStudent";
                $.post(url, result.value).done(function (data) {
                    if (data === "1") {
                        Swal.fire(
                            'Success!',
                            'Data added successfuly!',
                            'success'
                        )
                        GetStudents(result.value.ClassName);
                    }
                    else if (data === "Duplicate Class") {
                        Swal.fire(
                            'Error!',
                            data,
                            'error'
                        )
                    }
                    else {
                        Swal.fire(
                            'Error!',
                            data,
                            'error'
                        )
                    }
                });
            });
        } else {
            Swal.fire(
                'Error!',
                'No Class Selected!',
                'error'
            )
        }
    });

    //Edit Class
    $("#myTableClass tbody").on("click", "td button#edit-class", function () {
        let classnameVal = this.parentNode.parentNode.children[0].innerText;
        let locVal = this.parentNode.parentNode.children[1].innerText;
        let teacherNameVal = this.parentNode.parentNode.children[2].innerText;
        Swal.fire({
            title: 'Add Class',
            html: `<input type="text" id="className" class="swal2-input" placeholder="Class Name" value = "` + classnameVal+`">
                    <input type="text" id="location" class="swal2-input" placeholder="Location"  value = "` + locVal +`">
                    <input type="text" id="teacherName" class="swal2-input" placeholder="Teacher Name"  value = "` + teacherNameVal +`">`,

            confirmButtonText: 'Update',
            focusConfirm: false,
            preConfirm: () => {
                const classname = Swal.getPopup().querySelector('#className').value
                const location = Swal.getPopup().querySelector('#location').value
                const teacherName = Swal.getPopup().querySelector("#teacherName").value;
                if (!classname || !location || !teacherName) {
                    Swal.showValidationMessage(`Please enter value`)
                }
                return { classname: classname, location: location, teacherName: teacherName }
            }
        }).then((result) => {
            let url = "Home/EditClass";
            $.post(url, result.value).done(function (data) {
                if (data === "1") {
                    Swal.fire(
                        'Success!',
                        'Data added successfuly!',
                        'success'
                    )
                    let url = "Home/GetClasses";
                    $.get(url, function (result, status) {
                        tableClass.clear().draw();
                        result.map((res) => {
                            tableClass.row.add([
                                res.className,
                                res.location,
                                res.teacherName,
                                "<button id='edit-class'>Edit</button>",
                                "<button id='delete-class'>Delete</button>",
                            ]).draw(false);
                        })
                    });

                }
                else if (data === "Duplicate Class") {
                    Swal.fire(
                        'Error!',
                        data,
                        'error'
                    )
                }
                else if(data === "null"){
                    Swal.fire(
                        'Error!',
                        data,
                        'error'
                    )
                }
            });
        })
    })

    //Delete Class
    $("#myTableClass tbody").on("click","td button#delete-class", function () {
        let classnameVal = this.parentNode.parentNode.children[0].innerText;
        Swal.fire({
            title: 'Are you sure ?',
            showCancelButton: true,
            confirmButtonText: 'Delete',
            cancelButtonText: 'No, cancel!',
            focusConfirm: false,
            preConfirm: () => {
                const classname = classnameVal;
                if (!classname) {
                    Swal.showValidationMessage(`Please enter value`)
                }
                return { classname: classname }
            }
        }).then((result) => {
            let url = "Home/DeleteClass";
            $.post(url, result.value).done(function (data) {
                if (data === "1") {
                    Swal.fire(
                        'Success!',
                        'Data added successfuly!',
                        'success'
                    )
                    let url = "Home/GetClasses";
                    $.get(url, function (result, status) {
                        tableClass.clear().draw();
                        result.map((res) => {
                            tableClass.row.add([
                                res.className,
                                res.location,
                                res.teacherName,
                                "<button id='edit-class'>Edit</button>",
                                "<button id='delete-class'>Delete</button>",
                            ]).draw(false);
                        })
                    });

                }
                else if (data === "Duplicate Class") {
                    Swal.fire(
                        'Error!',
                        data,
                        'error'
                    )
                }
                else if (data == "null"){
                    Swal.fire(
                        'Error!',
                        data,
                        'error'
                    )
                }
            });
        })
    })

    //Edit Student
    $("#myTableStudent tbody").on("click", "td button#edit-student", function () {
        const className = $("#classValue").text();
        let idVal = this.parentNode.parentNode.children[0].innerText;
        let fullname = this.parentNode.parentNode.children[1].innerText.toString().split(" ");
        let firstNameVal;
        let lastNameVal;
        if (fullname.length > 2) {
            lastNameVal = fullname.pop();
            firstNameVal = fullname.join(" ");
        }
        else {
            firstNameVal = fullname[0];
            lastNameVal = fullname[1];
        }
        let ageVal = this.parentNode.parentNode.children[2].innerText;
        let GPAVal = this.parentNode.parentNode.children[3].innerText;
        Swal.fire({
            title: 'Edit Student',
            html: `<input type="text" id="firstName" class="swal2-input" placeholder="First Name" value = "` + firstNameVal + `">
                    <input type="text" id="lastName" class="swal2-input" placeholder="Last Name" value = "`+ lastNameVal +`">
                    <input type="text" id="age" class="swal2-input" placeholder="Age" value = "`+ ageVal + `">
                    <input type="text" id="gpa" class="swal2-input" placeholder="GPA" value = "`+ GPAVal + `">`,

            confirmButtonText: 'Update',
            focusConfirm: false,
            preConfirm: () => {
                const firstName = Swal.getPopup().querySelector('#firstName').value
                const lastName = Swal.getPopup().querySelector("#lastName").value;
                const age = Swal.getPopup().querySelector("#age").value;
                const gpa = Swal.getPopup().querySelector('#gpa').value
                if (!firstName || !lastName || !age || !gpa) {
                    Swal.showValidationMessage(`Please enter value`)
                }
                return { StudentId: idVal, FirstName: firstName, LastName: lastName, Age: age, GPA: gpa, ClassName: className }
            }
        }).then((result) => {
            let url = "Home/EditStudent";
            $.post(url, result.value).done(function (data) {
                if (data === "1") {
                    Swal.fire(
                        'Success!',
                        'Data added successfuly!',
                        'success'
                    )
                    let url = "Home/GetStudent";
                    GetStudents(result.value.ClassName);
                }
                else if (data === "Duplicate Class") {
                    Swal.fire(
                        'Error!',
                        data,
                        'error'
                    )
                }
                else if(data==="null") {
                    Swal.fire(
                        'Error!',
                        data,
                        'error'
                    )
                }
            });
        })
    })

    //Delete Student
    $("#myTableStudent tbody").on("click", "td button#delete-student", function () {
        let idVal = this.parentNode.parentNode.children[0].innerText;
        Swal.fire({
            title: 'Are you sure?',
            showCancelButton: true,
            confirmButtonText: 'Delete',
            cancelButtonText: 'No, cancel!',
            focusConfirm: false,
            preConfirm: () => {
                return { StudentId: idVal }
            }
        }).then((result) => {
            let url = "Home/DeleteStudent";
            $.post(url, result.value).done(function (data) {
                if (data === "1") {
                    Swal.fire(
                        'Success!',
                        'Data added successfuly!',
                        'success'
                    )
                    const className = $("#classValue").text();
                    GetStudents(className);
                }
                else if (data === "Duplicate Class") {
                    Swal.fire(
                        'Error!',
                        data,
                        'error'
                    )
                }
                else if(data === "null") {
                    Swal.fire(
                        'Error!',
                        data,
                        'error'
                    )
                }
            });
        })
    })
    function GetStudents(className) {
        tableStudent.clear().draw();
        let url = "Home/GetStudent?ClassName=";
        $("#classValue").text(className);
        $.get(url + className, function (result, status) {
            result.map((res,index) => {
                if (res.gpa > 3.2) {
                    tableStudent.row.add([
                        res.studentId,
                        res.firstName + " " + res.lastName,
                        res.age,
                        res.gpa,
                        "<button id='edit-student'>Edit</button>",
                        "<button id='delete-student'>Delete</button>",
                    ]).draw(false);
                    $(tableStudent.row(index).node()).children("td:nth-child(2)").addClass("highlight");
                }
                else {
                    tableStudent.row.add([
                        res.studentId,
                        res.firstName + " " + res.lastName,
                        res.age,
                        res.gpa,
                        "<button id='edit-student'>Edit</button>",
                        "<button id='delete-student'>Delete</button>",
                    ]).draw(false);
                }
            })
        });
    }
});