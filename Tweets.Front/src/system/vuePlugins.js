import { DateTime } from 'luxon';

const vuePlugin = {
    install(Vue, options) {
        function displayDateTime(dateValue, format) {
            if (!dateValue || dateValue.length === 0 || dateValue.trim().length === 0) {
                return '';
            }
            var date = DateTime.fromISO(dateValue).setZone('local');
            var dateString = date.toFormat(format);
            return dateString;
        };

        Vue.prototype.$displayDate = (dateValue) => displayDateTime(dateValue, 'dd.MM.yyyy');
        Vue.prototype.$displayDateTime = (dateValue) => displayDateTime(dateValue, 'dd.MM.yyyy HH:mm');
        Vue.prototype.$displayDateTimeSS = (dateValue) => displayDateTime(dateValue, 'dd.MM.yyyy HH:mm:ss');
    }
};

export default vuePlugin;
