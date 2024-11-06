// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", () => {
    const userListDiv = document.getElementById("userList");
    const searchInput = document.getElementById("searchInput");

    const userModal = document.createElement("div");
    userModal.id = "userModal";
    userModal.classList.add("modal");

    userModal.innerHTML = `
        <div class="modal-content">
            <span class="close">&times;</span>
            <h2 id="modalName"></h2>
            <p><strong>Email:</strong> <span id="modalEmail"></span></p>
            <p><strong>Phone:</strong> <span id="modalPhone"></span></p>
        </div>
    `;
    document.body.appendChild(userModal);

    const modalName = userModal.querySelector("#modalName");
    const modalEmail = userModal.querySelector("#modalEmail");
    const modalPhone = userModal.querySelector("#modalPhone");
    const closeModalButton = userModal.querySelector(".close");

    function displayUsers(users) {
        userListDiv.innerHTML = ""; 

        users.forEach((user) => {
            const userElement = document.createElement("div");
            userElement.classList.add("user-card");
            userElement.innerHTML = `<p><strong>${user.FirstName} ${user.LastName}</strong><br>Email: ${user.Email}</p>`;

            userElement.addEventListener("click", () => {
                modalName.textContent = `${user.FirstName} ${user.LastName}`;
                modalEmail.textContent = user.Email;
                modalPhone.textContent = user.Phone;

                userModal.style.display = "block";
            });

            userListDiv.appendChild(userElement);
        });
    }

    closeModalButton.addEventListener("click", () => {
        userModal.style.display = "none";
    });

    window.addEventListener("click", (event) => {
        if (event.target === userModal) {
            userModal.style.display = "none";
        }
    });

    if (window.usersData) {
        displayUsers(window.usersData); 

        searchInput.addEventListener("input", (e) => {
            const query = e.target.value.toLowerCase();
            const filteredUsers = window.usersData.filter(user => 
                user.FirstName.toLowerCase().includes(query) || 
                user.LastName.toLowerCase().includes(query) ||
                user.Email.toLowerCase().includes(query)
            );
            displayUsers(filteredUsers);
        });
    } else {
        console.error("No user data found in window.usersData!");
    }
});
