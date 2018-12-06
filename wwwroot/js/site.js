function GlobalLoader(visible) {

  if (visible) {
    $("#loader").modal({
      backdrop: "static", //remove ability to close modal with click
      keyboard: false, //remove option to close with keyboard
      show: true //Display loader!
    });
  }
  else {
    $("#loader").modal("hide");
  }

}