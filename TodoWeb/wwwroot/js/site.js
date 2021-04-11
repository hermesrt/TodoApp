$(document).ready(function () {

    const URL_API = "https://localhost:44368/";
    const $logincontainer = $("#loginContainer");
    const $groupContiner = $("#groupContiner");
    const $nameInput = $("#nameInput");
    const $passwordInput = $("#passwordInput");
    const $sendBtn = $("#sendBtn");
    const $groupContainer = $("#groupContainer");
    const groupTempalte = $("#groupRowTempalte");
    const $addGroupBtn = $("#addGroupBtn");
    const $addTodoBtn = $("#addTodoBtn");
    const $groupInput = $("#groupInput");
    const parseJwt = function (token) {
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));

        return JSON.parse(jsonPayload);
    };

    $addGroupBtn.click(function (e) {
        const token = parseJwt(localStorage.getItem("jwt"));
        $.ajax({
            type: "POST",
            url: URL_API + "api/TodoGroup",
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('jwt')
            },
            dataType: 'json',
            data: {
                UserId: parseInt(token.nameid),
                Name: $groupInput.val()
            }
        })
    });


    $sendBtn.click(function (e) {
        e.preventDefault();
        $.post(URL_API + "auth/login", {
            Name: $nameInput.val(),
            Password: $passwordInput.val()
        }
        )
            .then(function (e) {

                localStorage.setItem('jwt', e)
                $.ajax({
                    type: "GET",
                    url: URL_API + "api/TodoGroup",
                    headers: {
                        Authorization: 'Bearer ' + localStorage.getItem('jwt')
                    },
                    dataType: 'json',
                })
                    .then(function (groups) {
                        debugger;
                        for (let i = 0; i < groups.length; i++) {
                            const group = groups[i];
                            const $row = $(groupTempalte.text())
                            const $name = $row.find("[name=name]");
                            $name.text(group.name);
                            const $todosBtn = $row.find("[name=todosBtn]");
                            $todosBtn.click(function () { debugger; })
                            const $deleteGroupBtn = $row.find("[name=deleteGroupBtn]");
                            $deleteGroupBtn.click(function () { debugger; })
                            $groupContainer.append($row);
                        }
                        $logincontainer.hide();
                        $groupContiner.show();
                    });
            })
            .fail(function (e) {
                debugger;
            });
    });
})