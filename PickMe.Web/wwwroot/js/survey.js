document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".vote-button").forEach(function (element) {
        element.addEventListener("click", function () {
            const surveyId = this.getAttribute("data-survey-id");
            const isFirstImage = this.getAttribute("data-image") === "1";

            fetch("/Survey/Vote", {
                method: "POST",
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded",
                    "RequestVerificationToken": document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: `surveyId=${surveyId}&isFirstImage=${isFirstImage}`
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        alert("Oyunuz başarıyla kaydedildi!");
                        location.reload(); // Oy sayısını güncellemek için sayfayı yenile
                    } else {
                        alert("Hata: " + data.message);
                    }
                })
                .catch(error => console.error("Hata:", error));
        });
    });
});
