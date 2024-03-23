<script lang="ts">
    import NavPanel from "$components/panels/NavPanel.svelte";
    import {faCoffee} from '@fortawesome/free-solid-svg-icons';
    import {PanelObject} from "$components/boards/panelObject";

    let items: PanelObject[] = [
        new PanelObject(
            "fa-lightbulb",
            "Title Test",
            "Description Test",
            "/stand-up"
        )
    ];
</script>

<style lang="css">
    .board {
        border: 2px solid black;
        border-radius: 1rem;

    &
    .nodes-container {
        padding: 2rem;
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        justify-content: space-between;
    }

    }

</style>

<div class="board">
    <div class="nodes-container">
        {#each items as item}
            <NavPanel icon={item.icon} title={item.title} contents={item.description}/>
        {/each}
    </div>
</div>