import { createRouter, createWebHistory } from "vue-router";

import Home from "../Views/MainView/MainView.vue";
import ApiEditForm from "../Views/MainView/Children/ApiEditForm.vue";

const router = createRouter({
	history: createWebHistory(),
	routes: [
		{
			path: "/",
			name: "home",
			component: Home,
		},
		{
			path: "/EditApi",
			name: "EditApi",
			component: ApiEditForm,
			props: () => ({
				SelectedApi: history.state.Api,
			}),
		},
	],
});

export default router;
