document.getElementById('rating-form').addEventListener('submit', function (e) {
    e.preventDefault();
    const recipeName = document.getElementById('recipe-name').value;
    const rating = document.getElementById('rating').value;
    addRating(recipeName, rating);
    this.reset();
});

function addRating(name, rating) {
    const list = document.getElementById('ratings-list');
    const li = document.createElement('li');
    li.innerHTML = `${name} - Rating: ${rating} <button onclick="editRating(this)">Edit</button> <button onclick="deleteRating(this)">Delete</button>`;
    list.appendChild(li);
}

function editRating(btn) {
    const li = btn.parentNode;
    const parts = li.textContent.split(' - Rating: ');
    let currentRating = parts[1].split(' ')[0]; // Getting the current rating
    let newRating = prompt("Update the rating (1-5)", currentRating);

    // Validation: check if the input is a number and between 1 and 5
    newRating = parseInt(newRating);
    if (!newRating || newRating < 1 || newRating > 5) {
        alert('Please enter a valid rating between 1 and 5.');
        return;
    }

    li.innerHTML = `${parts[0]} - Rating: ${newRating} <button onclick="editRating(this)">Edit</button> <button onclick="deleteRating(this)">Delete</button>`;
}

function deleteRating(btn) {
    if (confirm('Are you sure you want to delete this rating?')) {
        btn.parentNode.remove();
    }
}
