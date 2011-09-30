$(function () {
	$('#anagramlookup form').submit(function (event) {
		event.preventDefault();
		console.log("Hi");
		$.ajax({
			type: "POST",
			url: this.action,
			data: $(this).serialize(),
			success: function (json) {
				var html = '';
				$.each(json.Anagrams, function (key, value) {
					html = html + '<li>' + value + '</li>';
				});
				$('#result ul').html(html);
			}
		});
	});
});