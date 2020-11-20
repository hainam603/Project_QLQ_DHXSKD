// src/plugins/vuetify/theme.js

import colors from "vuetify/lib/util/colors";

export default {
  primary: {
    base: colors.blue.base,
    darken1: colors.red.darken2,
  },
  secondary: colors.pink,
  // All keys will generate theme styles,
  // Here we add a custom `tertiary` color
  tertiary: colors.pink.base,
};
