document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    if (calendarEl) {
        // Daha önce bir calendar nesnesi varsa destroy et
        if (window.fcCalendar) {
            window.fcCalendar.destroy();
        }
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
                window.location.href = '/Etkinlik/Details/' + info.event.id;
            }
        });
        window.fcCalendar = calendar;
        calendar.render();
    }
});