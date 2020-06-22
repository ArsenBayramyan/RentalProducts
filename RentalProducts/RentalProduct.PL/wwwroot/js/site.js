function SaveExcel() {
	value = $("#inputValue").val();
	$.ajax({
		url: `../Home/Report/?modelName=${value}`,
		enctype: 'json',
		success: function (data) {
			if (data != null) {
				var bytes = base64ToArrayBuffer(data);
				saveByteArray([bytes], "report.xlsx");
			}
		}
	});
}


function base64ToArrayBuffer(base64) {
	var binaryString = window.atob(base64);
	var binaryLen = binaryString.length;
	var bytes = new Uint8Array(binaryLen);
	for (var i = 0; i < binaryLen; i++) {
		var ascii = binaryString.charCodeAt(i);
		bytes[i] = ascii;
	}
	return bytes;
}

// Save byte array as file
var saveByteArray = (function () {
	var a = document.createElement("a");
	document.body.appendChild(a);
	a.style = "display: none";
	return function (data, name) {
		var blob = new Blob(data, { type: "octet/stream" }), url = window.URL.createObjectURL(blob);
		if (window.navigator && window.navigator.msSaveOrOpenBlob) {
			window.navigator.msSaveOrOpenBlob(blob, name);
		}
		else {
			a.href = url;
			a.download = name;
			a.click();
			window.URL.revokeObjectURL(url);
		}
	};
}());
