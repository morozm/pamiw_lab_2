document.addEventListener("DOMContentLoaded", function () {
    const quoteList = document.getElementById('quoteList');
    const quoteInput = document.getElementById('quoteInput');
    const authorInput = document.getElementById('authorInput');
    const addQuoteButton = document.getElementById('addQuote');

    // Funkcja do pobierania cytatów z Local Storage
    function getQuotes() {
        const quotes = localStorage.getItem('quotes');
        return quotes ? JSON.parse(quotes) : [];
    }

    // Funkcja do zapisywania cytatów do Local Storage
    function saveQuotes(quotes) {
        localStorage.setItem('quotes', JSON.stringify(quotes));
    }

    // Funkcja do renderowania cytatów na stronie
    function renderQuotes() {
        quoteList.innerHTML = ''; // Czyścimy listę
        const quotes = getQuotes();
        quotes.forEach((quote, index) => {
            const li = document.createElement('li');
            li.textContent = `"${quote.Text}" - ${quote.Author}`;

            // Dodaj przycisk do edycji
            const editButton = document.createElement('button');
            editButton.textContent = 'Edytuj';
            editButton.className = 'edit';
            editButton.onclick = () => editQuote(index);

            // Dodaj przycisk do usuwania
            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Usuń';
            deleteButton.onclick = () => deleteQuote(index);

            li.appendChild(editButton);
            li.appendChild(deleteButton);
            quoteList.appendChild(li);
        });
    }

    // Funkcja do dodawania nowego cytatu
    function addQuote() {
        const quoteText = quoteInput.value.trim();
        const authorText = authorInput.value.trim();
        if (quoteText && authorText) {
            const quotes = getQuotes();
            quotes.push({ Text: quoteText, Author: authorText });
            saveQuotes(quotes);
            quoteInput.value = ''; // Czyści pole input
            authorInput.value = ''; // Czyści pole input
            renderQuotes(); // Odświeża widok
        } else {
            alert('Proszę wpisać zarówno cytat, jak i autora!');
        }
    }

    // Funkcja do edytowania cytatu
    function editQuote(index) {
        const quotes = getQuotes();
        const newQuote = prompt('Edytuj cytat:', quotes[index].Text);
        const newAuthor = prompt('Edytuj autora:', quotes[index].Author);
        if (newQuote !== null && newQuote.trim() && newAuthor !== null && newAuthor.trim()) {
            quotes[index] = { Text: newQuote.trim(), Author: newAuthor.trim() };
            saveQuotes(quotes);
            renderQuotes(); // Odświeża widok
        }
    }

    // Funkcja do usuwania cytatu
    function deleteQuote(index) {
        const quotes = getQuotes();
        quotes.splice(index, 1); // Usuwa cytat
        saveQuotes(quotes);
        renderQuotes(); // Odświeża widok
    }

    // Inicjalizacja aplikacji
    addQuoteButton.onclick = addQuote;
    renderQuotes(); // Wywołanie renderowania cytatów przy ładowaniu
});
