﻿function Notify(data) {
    Swal.fire({
        title: data.title,
        message: data.message,
        icon: data.type
    });
}