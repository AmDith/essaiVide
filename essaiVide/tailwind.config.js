/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Views/**/*.cshtml", // Parcourt toutes les vues Razor
    "./wwwroot/**/*.js",   // Fichiers JS dans wwwroot
  ],
  theme: {
    extend: {},
  },
  plugins: [],
};


