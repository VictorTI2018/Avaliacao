import Vue from "vue";
import { library } from "@fortawesome/fontawesome-svg-core";
import {
  faSave,
  faEdit,
  faTrash,
  faBan,
  faUser,
  faFont,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

library.add(faSave, faEdit, faTrash, faBan, faUser, faFont);

Vue.component("v-icon", FontAwesomeIcon);
