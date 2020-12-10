(function () {
    const alertElement = document.getElementById("success-alert");
    const errorAlertElement = document.getElementById("error-alert");
    const form = document.forms[0];
    const list = document.getElementById("list");
    const msg = document.getElementById("msg");
    const addNewItem = async () => {
        const requestData = JSON.stringify({
            Name: document.getElementById("Name").value,
            Description: document.getElementById("Description").value,
            IsVisible: document.getElementById("IsVisible").checked
        });

        const response = await fetch("/api/exchanges", {
            method: "POST",
            headers: {
                "Content-type": "application/json"
            },
            body: JSON.stringify(requestData),
        });

        const responseJson = await response.json();

        if (responseJson.success) {
            alertElement.style.display = "";
            var HTML = "<table border=1 width=100%><tr><th>Name</th><th>Description</th><th>Visibility</th></tr>";

            responseJson.data.forEach(element => {
                HTML += "<tr><td align=center>" + element.name + "</td>";
                HTML += "<td align=center>" + element.description + "</td>";
                HTML += "<td align=center>" + element.isVisible + "</td></tr>";
            });

            HTML += "</table>";

            list.innerHTML = HTML;
            list.style.display = "";
        } else {
            errorAlertElement.style.display = "";
            msg.innerText = responseJson.message;
        }
    };
    window.addEventListener("load", () => {
        form.addEventListener("submit", event => {
            event.preventDefault();
            alertElement.style.display = "none";
            errorAlertElement.style.display = "none";
            list.style.display = "none";
            addNewItem().then(() => console.log("added successfully"));
        });
    });
})();