// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const circles = $('.progress-ring__circle');
const radius = circles.first().attr('r');
const circumference = radius * 2 * Math.PI;

let data = [];
circles.each(function(index){
    data[index] = "";
})

function setProgress(percent) {
    const offset = circumference - percent / 100 * circumference;
}