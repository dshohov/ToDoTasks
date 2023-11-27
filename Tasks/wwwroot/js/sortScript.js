function sortTasks() {
    var sortOrder = document.getElementById("sortOrder").value;
    var items = document.querySelectorAll(".list-group-item");

    var sortedItems = Array.from(items).sort(function (a, b) {
        var idA = parseInt(a.id);
        var idB = parseInt(b.id);

        if (sortOrder === "asc") {
            return idA - idB;
        } else {
            return idB - idA;
        }
    });

    var list = document.querySelector(".list-group");
    list.innerHTML = "";
    sortedItems.forEach(function (item) {
        list.appendChild(item);
    });
}