
var tickets = [];

function validateEmail(email) {
	var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
	return re.test(email);
}

function checkBuyTicketForm() {
	var nm = $('#buyerName').val().trim();
	var email = $('#buyerEmail').val().trim();
	if (!nm) {
		alert('Пожалуйста, укажите Ваше имя.');
		return false;
	}

	var nm1 = /[<>{}!~#$%^&*()_\+,\.\/\\]/.replace(nm, "");
	if (nm != nm1) $('#buyerName').val(nm1);

	if (!$('#buyerEmail').val()) {
		alert('Пожалуйста, укажите Ваше адрес электронной почты. На него будет отправлен Ваш электронный билет.');
		return false;
	}
	if (!validateEmail($('#buyerEmail').val())) {
		alert('Ошибка в адресе электронной почты. Проверьте, что адрес указан верно.');
		return false;
	}
	return true;
}

$(function () {

	function refr() {
		var s = '<table><tr><td>Выбрано билетов: ' + tickets.length + '<br>';
		var totPr = 0;
		var seats = '';
		for (var i = 0; i < tickets.length; i++) {
			s += 'Место: ' + tickets[i].seat + '. Цена: $' + Number(tickets[i].pr).toFixed(0) + '<br>';
			seats += tickets[i].seat + ',';
			totPr += +tickets[i].pr;
		}
		s += "<br>Итого: $" + Number(totPr).toFixed(0);
		s += '</td><td class=ticketBuyFormCont><form method=post action="/ticketBuyRequest.aspx">'
			+ '<input type="hidden" name="eventId" value="' + eventId + '"/>'
			+ '<input type="hidden" name="seats" value="' + seats + '"/>'
			+ '<input type="text" maxlength=100 id=buyerName name="buyerName" placeholder="Ваше имя" value=""/>'
			+ '<input type="text" maxlength=250 name=buyerEmail name="buyerEmail" placeholder="Ваш e-mail" value=""/>'
			+ '<input type=submit onclick="checkBuyTicketForm()" class="buyButton" value="Купить"/></form>';
		s += '</td></tr></table>';
		$('#ticketInfoBox').html(s);
	}

	var ss = $('.hall-map a[data-n]');

	for (var i = 0; i < ss.length; i++) {

		var seat = ss[i].getAttribute('data-n');
		var found = false;
		for (var j = 0; j < avaliableTickets.length; j++) {
			var stDt = avaliableTickets[j];
			if (stDt.seat == seat) {
				$(ss[i])
					.addClass('aval')
					.attr('href', '#')
					.attr('data-num', j)
					.click(function () {
						var cj = +$(this).attr('data-num');
						var t = avaliableTickets[cj];
						var idx = tickets.indexOf(t);
						if (idx !== -1) {
							tickets.splice(idx, 1);
							$(this).removeClass('selSeat');
						} else {
							tickets.push(t);
							$(this).addClass('selSeat');
						}

						refr();
						return false;
					});
				found = true;
				break;
			}
		}
		if (!found) {
			$(ss[i]).css('background-color', 'gainsboro');
		}
	}

});