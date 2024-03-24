<script lang="ts">
    import { getContext, setContext } from "svelte";
	import BaseDrawer from '$components/drawers/BaseDrawer.svelte';
	import baseDrawerStore from '$stores/baseDrawerStore';
	import IBaseDrawer from '$stores/baseDrawerStore';
	import {MenuItem} from '$components/drawers/drawerObjects';
    import { goto } from "$app/navigation";
	import Button from '$bcl/Button.svelte';

    let isMenuOpen:  boolean = false;

	$: isMenuOpen = $baseDrawerStore;

	// Define your list of options here
    const options = [
        "Option 1",
        "Option 2",
        "Option 3"
    ];

	function testFunc() {
		setContext('pause-overlay', true);
	}
</script>

<div class="top-nav">
	<div>Herd Your Cats</div>
	<div class="actions">
		<Button action={() => goto("/")}>Home <i class="fa-solid fa-house"></i></Button>
		<Button action={() => testFunc()}>Test <i class="fa-solid fa-vials"></i></Button>
		{#if isMenuOpen}
            <!-- <div class="menu">
                {#each options as option}
                    <div class="option">{option}</div>
                {/each}
            </div> -->
        {/if}
	</div>
</div>

<style lang="css">
	@import "../../routes/global-styles.css";

	.top-nav {
		z-index: var(--top-nav-header-z-index);
		box-sizing: border-box;
		position: fixed;
		top: 0;
		height: var(--top-nav-header-height);
		left: 0;
		width: 100%;
		padding: 1rem 1.5rem ;
		display: flex;
		align-items: center;
		background-color: var(--hys-primary-color);
		color: white;
		border-bottom: .2rem solid var(--hys-primary-color-light);

		& .actions {
			margin-left: auto;
		}

		& .menu {
			position: absolute;
			right: 0;
			background-color: var(--hys-primary-color-light);
			border: 1px solid #ccc;
			padding: 1rem;
		}

		& .option {
			padding: 5px;
			cursor: pointer;
		}

		& .option:hover {
			background-color: #f0f0f0;
		}
	}
</style>