<script lang="ts">
    import {library, dom} from '@fortawesome/fontawesome-svg-core'
    import {PanelObject} from "$components/boards/panelObject";
    import {goto} from '$app/navigation';
    
    export let icon: string = 'fa-lightbulb';
    export let title: string = 'Title PlaceHolder';
    export let description: string = 'Contents PlaceHolder';
    
    function hitThis() {
        goto('/stand-up')
    }
</script>

<style lang="css">
    @import '../../routes/global-styles.css';
    .nav-panel-container {
        border: 2px solid var(--hys-primary-color-3);
        border-radius: 0.5rem;
        height: 20rem;
        width: 20rem;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        font-family: Arial, Helvetica, sans-serif;
        background-color: var(--hys-primary-color-4);

        &:hover:not(&.disabled) {
            background-color: var(--hys-primary-color-3);
            border-color: var(--hys-primary-color-4);
            cursor: pointer;
         }

    &
    .header {
        font-size: 1.5rem;
        font-weight: bold;
    }

    &
    .icon-item {
        font-size: 2rem;
    }

    }
</style>

<div class="nav-panel-container" on:click={() => hitThis()}>
    <div class="panel-item icon-item"><i class="fa-regular {icon}"></i></div>
    <div class="panel-item header">{title}</div>
    <div class="panel-item body">{description}</div>
</div>
