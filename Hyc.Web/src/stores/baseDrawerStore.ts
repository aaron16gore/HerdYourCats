import { writable } from 'svelte/store';
import type { Writable } from 'svelte/store';

const baseDrawerStore: Writable<boolean> = writable(false);

export default baseDrawerStore;