<script lang="ts">
    import { fade, fly } from "svelte/transition";
    import { quintOut } from "svelte/easing";

    enum Position {
        Left = "left",
        Right = "right",
    }

    export let isOpen: boolean = false;
    export let screenPosition: Position = Position.Right;
</script>

{#if isOpen}
    <div class="base-drawer" transition:fly={{ y: "-100%", opacity: 100 }}>
        <div class="header">
            <div class="contents">Header</div>
            <div class="contents">Sub Header</div>
        </div>
        <div class="body">
            <div>
                <div style="margin-bottom: 2000px;">Test</div>
                <div>Test</div>
            </div>
        </div>
    </div>
{/if}

<style lang="css">
    .base-drawer {
        position: absolute;
        background-color: var(--hys-primary-color-light);
        min-height: inherit;
        width: 50%;
        top: 0;
        right: 0;

        & .header {
            height: 50px;
            background-color: var(--hys-primary-color-red);
            color: var(--hys-white-color);
            padding: 1rem;
            border: 0.1rem solid black;
            display: flex;
            gap: 10rem;
            align-items: center;
        }

        & .body {
            position: absolute;
            background-color: var(--hys-white-color);
            height: var(--base-canvas-height);
            width: 100%;
            overflow: auto;
        }
    }
</style>
