// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

//alert("JS example interop1");

export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}

export function displayMessage(message) {
    return alert(message);
}