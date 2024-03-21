<script lang="ts">
    import MenuDrawer from "$components/drawers/MenuDrawer.svelte";
    import { MenuItem } from "$components/drawers/drawerObjects";

    export let isOpen: boolean = false;

    let menuItems: MenuItem[] = [
        new MenuItem("Logout (Not Implemented)", logoutUser),
    ];

    function logoutUser() {
        alert("Logout is not currently implemented");
    }
</script>

{#if isOpen}
    <MenuDrawer bind:isOpen bind:menuItems />
{/if}

<style lang="css">
</style>
