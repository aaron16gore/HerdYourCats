import { sveltekit } from '@sveltejs/kit/vite';
import { defineConfig } from 'vite';
import FullReload from 'vite-plugin-full-reload'

export default defineConfig({
	plugins: [
		sveltekit(),
		FullReload(['config/routes.rb', '*'])
	]
});
