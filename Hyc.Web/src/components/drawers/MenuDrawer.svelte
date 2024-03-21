<script lang="ts">
    import { fade, fly } from "svelte/transition";
    import { quintOut } from "svelte/easing";
    import {MenuItem} from '$components/drawers/drawerObjects';

    enum Position {
        Left = "left",
        Right = "right",
    }

    export let isOpen: boolean = false;
    export let screenPosition: Position = Position.Right;
    export let menuItems: MenuItem[] = [];
</script>

{#if isOpen}
    <div class="base-drawer" transition:fly={{ y: "-100%", opacity: 100 }}>
        <div class="body">
            {#each menuItems as item}
                <div class="item" on:click={item.menuItemAction}>{item.menuItemRender}</div>
            {/each}
        </div>
    </div>
{/if}

<style lang="css">
    .base-drawer {
        position: absolute;
        background-color: var(--hys-primary-color-light);
        width: 20rem;
        top: 0;
        right: 0;
        border: 1px solid black;

        & .body {
            display: flex;
            flex-direction: column;

            & .item {
                padding: 1rem;
            }

            & .item:not(:last-child) {
                border-bottom: 1px solid black;
            }
        }
    }
</style>
