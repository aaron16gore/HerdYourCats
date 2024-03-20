<script lang="ts">
    import TopNavHeader from "$components/headers/TopNavHeader.svelte";
    import BaseDrawer from "$components/drawers/BaseDrawer.svelte";
    import { onMount, getContext } from "svelte";
    import baseDrawerStore from '$stores/baseDrawerStore';

    let isBaseDrawerOpen: boolean = false;

    baseDrawerStore.subscribe((o) => {
		isBaseDrawerOpen = o;
	});
</script>

<style lang="css" src="./+layout.css"></style>

<html lang="en">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Herd Your Cats</title>
    <body>
        <header>
            <TopNavHeader />
        </header>
        <main>
            <BaseDrawer bind:isOpen={isBaseDrawerOpen}/>
        </main>
    </body>
</html>