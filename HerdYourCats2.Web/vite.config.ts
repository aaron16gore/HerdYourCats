import { sveltekit } from '@sveltejs/kit/vite';
import type { UserConfig } from 'vite';

const config: UserConfig = {
    plugins: [
        sveltekit()
    ],
    server: {
        strictPort: true,
        port: 6000
    }
};
export default config;
