<script lang="ts">
    import { PanelObject } from "$components/boards/panelObject";

    export let props: PanelObject;

    function handlePanelClick(event: MouseEvent) {
        props.panelAction();
    }
</script>

<button class="nav-panel-container" on:click={handlePanelClick}>
    <div class="panel-item icon-item"><i class={props.icon}></i></div>
    <div class="panel-item label">{props.title}</div>
    <div class="panel-item description" style="text-wrap: wrap;">{props.description}</div>
</button>

<style lang="css">
    @import "../../routes/global-styles.css";
    .nav-panel-container {
        border: 2px solid var(--hys-primary-color-3);
        border-radius: 0.5rem;
        padding: 1rem;
        aspect-ratio: 1 / 1;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        gap: 1rem;
        font-family: Arial, Helvetica, sans-serif;
        white-space: normal;
        word-wrap: break-word;
        overflow: hidden;
        background-color: var(--hys-primary-color-4);

        &:hover:not(&.disabled) {
            background-color: var(--hys-primary-color-3);
            border-color: var(--hys-primary-color-4);
            cursor: pointer;
        }

        & .icon-item {
            font-size: 4rem;
        }

        & .label {
            font-size: 2rem;
            font-weight: bold;
            width: 100%;
            text-align: center;
        }

        & .line-divider {
            border-top: 2px solid white;
            width: 100%;
        }

        & .description {
            word-wrap: break-word;
            font-size: 1rem;
            text-wrap: wrap;
        }
    }

    @media (max-width: 700px) {
    .nav-panel-container .description {
        display: none;
    }
}
</style>
