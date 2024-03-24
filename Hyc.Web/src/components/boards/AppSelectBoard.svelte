<script lang="ts">
    import NavPanel from "$components/panels/NavPanel.svelte";
    import { PanelObject } from "$components/boards/panelObject";
    import { goto } from "$app/navigation";
    import { onMount } from "svelte";

    const defaultWebGridWidth: number = 4;
    const defaultMobGridWidth: number = 2;

    let webGridWidth: number = defaultWebGridWidth;
    let mobGridWidth: number = defaultMobGridWidth;
    let navItems: PanelObject[] = [];

    onMount(() => {
        populateNavItems();
        calculateGridLayoutProps();
    });

    function populateNavItems() {
        navItems = [
            new PanelObject(
                "fa-solid fa-people-group",
                "Team Standup",
                "Conduct your daily team standup.",
                () => goto("/stand-up"),
            ),
            new PanelObject(
                "fa-solid fa-gamepad",
                "Retro",
                "Relax and bitch.",
                () => goto("/retro"),
            ),
            
           
            
        ];
    }

    function calculateGridLayoutProps() {
        let itemCount = navItems.length;

        if ((itemCount > 4 && itemCount < 7) || itemCount >= 9) {
            webGridWidth = 3;
        } else {
            webGridWidth = Math.min(itemCount, defaultWebGridWidth);
        }
        
        mobGridWidth = Math.min(itemCount, defaultMobGridWidth);

        document.documentElement.style.setProperty(
            "--web-grid-width",
            webGridWidth.toString(),
        );
        document.documentElement.style.setProperty(
            "--mob-grid-width",
            mobGridWidth.toString(),
        );
    }
</script>

<div class="container">
    <div class="grid-container">
        {#each navItems as item}
            <NavPanel props={item}></NavPanel>
        {/each}
    </div>
</div>

<style lang="css">
    .container {
        height: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
    }

    .grid-container {
        width: 100%;
        max-width: 80%;
        display: grid;
        gap: 10px;
        padding: 10px;
        grid-template-columns: repeat(auto-fill, minmax(7rem, 1fr));
    }

    @media (max-width: 768px) {
        .grid-container {
            grid-template-columns: repeat(var(--mob-grid-width, 2), 1fr);
        }
    }

    @media (min-width: 769px) {
        .grid-container {
            grid-template-columns: repeat(var(--web-grid-width), 1fr);
        }
    }

    .square {
        background-color: #007bff; /* Example color */
        width: 100%;
        padding-top: 100%; /* Aspect ratio trick */
        position: relative;
    }

    .square .content {
        position: absolute;
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        text-align: center; /* Ensures text is centered */
    }
</style>
