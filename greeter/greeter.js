'use strict';

class Greeter {
    greet(name, date) {
        const formattedName = this._formatName(name);
        const greeting = this._getGreeting(date);
        const message = `${greeting} ${formattedName}`;
        console.log(message);
        return message;
    }

    _formatName(name) {
        const trimmed = name.trim();
        return trimmed.charAt(0).toUpperCase() + trimmed.slice(1).toLowerCase();
    }

    _getGreeting(date) {
        if (!date || !(date instanceof Date)) return 'Hello';
        const hour = date.getHours();
        if (hour >= 6 && hour < 12) {
            return 'Good morning';
        }
        if (hour >= 18 && hour < 22) {
            return 'Good evening';
        }
        if (hour >= 22 || hour < 6) {
            return 'Good night';
        }
        return 'Hello';
    }
}

module.exports = Greeter;
