function Notify(data) {
    Swal.fire({
        title: data.title,
        text: data.message,
        icon: data.type
    });
}

function Navigate(data) {
    window.location.href = data.path;
}