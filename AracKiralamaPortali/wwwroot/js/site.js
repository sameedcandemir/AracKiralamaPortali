// Şifre alanlarındaki göster/gizle düğmesi
document.querySelectorAll(".sifre-goster").forEach(function (dugme) {
    dugme.addEventListener("click", function () {
        const alan = dugme.parentElement.querySelector("input");
        const ikon = dugme.querySelector("i");
        const gizliydi = alan.type === "password";

        alan.type = gizliydi ? "text" : "password";
        ikon.className = gizliydi ? "bi bi-eye-slash" : "bi bi-eye";
        dugme.setAttribute("aria-label", gizliydi ? "Şifreyi gizle" : "Şifreyi göster");
        dugme.setAttribute("aria-pressed", gizliydi ? "true" : "false");
    });
});
