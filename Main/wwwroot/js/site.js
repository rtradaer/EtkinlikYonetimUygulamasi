document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        locale: 'tr',
        height: 'auto',
        events: etkinlikler,
        timeZone: 'UTC',
        initialView: 'listMonth',
        initialDate: '2025-08-29',
        navLinks: true,
        editable: true,
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'listMonth,listYear'
        },
        views: {
            listMonth: { buttonText: 'Listele (Ay)' },
            listYear: { buttonText: 'Listele(Yıl)' }
        },
        eventClick: function (info) {
            // info.event.id ile etkinlik id'sini alabilirsin
            window.location.href = '/Etkinlik/Details/' + info.event.id;
        }
    });

    calendar.render();
});