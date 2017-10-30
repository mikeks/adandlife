
var tickets = [];

function validateEmail(email) {
	var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
	return re.test(email);
}

function checkBuyTicketForm() {
	var nm = $('#buyerName').val().trim();
	var email = $('#buyerEmail').val().trim();
	if (!nm) {
		$('#ticketFormError').text('Пожалуйста, укажите Ваше имя.');
		return false;
	}

	var nm1 = nm.replace(/[<>{}!~#$%^&*()_\+,\.\/\\]/g, "");
	if (nm !== nm1) $('#buyerName').val(nm1);

	if (!$('#buyerEmail').val()) {
		$('#ticketFormError').text('Пожалуйста, укажите Ваше адрес электронной почты. На него будет отправлен Ваш билет.');
		return false;
	}
	if ($('#userRefferer').val() === "notSet") {
		$('#ticketFormError').text('Пожалуйста, укажите как Вы о нас узнали.');
		return false;
	}
	if (!validateEmail($('#buyerEmail').val())) {
		$('#ticketFormError').text('Ошибка в адресе электронной почты. Проверьте, что адрес указан верно.');
		return false;
	}

	if (!$('#cbAgreed')[0].checked) {
		$('#ticketFormError').text('Вы должны согласиться с условиями продажи билетов для продолжения.');
		return false;
	}

	return true;
}

function submitForm() {
	if (checkBuyTicketForm()) $('#buyForm')[0].submit();
	return false;
}

function buyStep1() {
	$('#step0').hide();
	$('#step1').show();
	$('#step2').hide();
	return false;
}


function buyStep2() {
	$('#step0').hide();
	$('#step1').hide();
	$('#step2').show();
	return false;
}

$(function () {

	function refr() {
		var s = 'Выбрано билетов: ' + tickets.length + '<br>';
		if (tickets.length > 1) s += "Места: "; else s += "Место "
		var totPr = handlingFee;
		var seats = '';
		for (var i = 0; i < tickets.length; i++) {
			if (i > 0) s += ", ";
			s += tickets[i].seat + ' ($' + Number(tickets[i].pr).toFixed(2) + ')';
			seats += tickets[i].seat + ',';
			totPr += +tickets[i].pr;
		}
		var totPr = "$" + Number(totPr).toFixed(2);
		s += "<br>Handling fee: $" + handlingFee;
		s += "<br>Итого: " + totPr;
		s += "<div style='margin-top:5px'><a href='#' class='button ticket-buy-button' onclick='buyStep2();return false'>Далее</a></div>"

		$('#hSeats').val(seats);

		//s += '</td><td class=ticketBuyFormCont><form method=post action="/ticketBuyRequest.aspx">'
		//	+ '<input type="hidden" name="eventId" value="' + eventId + '"/>'
		//	+ '<input type="hidden" name="seats" value="' + seats + '"/>'
		//	+ '<input type="text" maxlength=100 id=buyerName name="buyerName" placeholder="Ваше имя" value=""/>'
		//	+ '<input type="text" maxlength=250 name=buyerEmail name="buyerEmail" placeholder="Ваш e-mail" value=""/>'
		//	+ '<input type=submit onclick="checkBuyTicketForm()" class="buyButton" value="Купить"/></form>';
		//s += '</td></tr></table>';
		$('#ticketInfoBox').html(s).show();
		var msg = "";
		if (tickets.length == 1) msg = "Выбран 1 билет на сумму " + totPr;
		else if (tickets.length < 5) msg = "Выбрано " + tickets.length + " билета на общую сумму " + totPr;
		else msg = "Выбрано " + tickets.length + " билетов на общую сумму " + totPr;
		$('#ticketInfoShort').text(msg);
	}

	var ss = $('.hall-map a[data-n]');
	var f = false;
	for (var i = 0; i < ss.length; i++) {

		var seat = ss[i].getAttribute('data-n');
		var found = false;
		for (var j = 0; j < avaliableTickets.length; j++) {
			var stDt = avaliableTickets[j];
			if (stDt.seat === seat) {
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
							$(this).removeClass('sel-seat');
						} else {
							tickets.push(t);
							$(this).addClass('sel-seat');
						}

						refr();
						return false;
					});
				if (!f) ss[i].focus();
				f = true;
				found = true;
				break;
			}
		}
		if (!found) {
			$(ss[i]).addClass('dis-seat');
		}
	}

});