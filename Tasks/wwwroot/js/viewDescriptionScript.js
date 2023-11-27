function toggleDescription(itemId) {
    var descriptionElement = document.getElementById(`description-${itemId}`);
    if (descriptionElement.style.display === 'none') {
        descriptionElement.style.display = 'block';
    } else {
        descriptionElement.style.display = 'none';
    }
}